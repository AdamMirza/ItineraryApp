using ItineraryBackend.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItineraryBackend.Providers
{
    public class TripCosmosDB
    {
        private CosmosClient client;
        private Database database;
        private Container tripContainer;
        private Container eventContainer;

        private IConfiguration config;

        public TripCosmosDB(string endpointUri, string primaryKey, IConfiguration config)
        {
            this.client = new CosmosClient(endpointUri, primaryKey);
            this.config = config;
        }

        public async Task CreateDB(string databaseId)
        {
            this.database = await this.client.CreateDatabaseIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseId).ToString());
        }

        public async Task CreateTripContainer()
        {
            this.tripContainer = await this.database.CreateContainerIfNotExistsAsync(UriFactory.CreateDocumentCollectionUri(database.Id, "TripContainer").ToString(), "/Title");
        }

        public async Task CreateEventContainer()
        {
            this.eventContainer = await this.database.CreateContainerIfNotExistsAsync(UriFactory.CreateDocumentCollectionUri(database.Id, "EventContainer").ToString(), "/Name");
        }

        public async Task AddTripToContainerAsync(Trip trip)
        {
            try
            {
                ItemResponse<Trip> tripResponse = await this.tripContainer.ReadItemAsync<Trip>(
                                                                                UriFactory.CreateDocumentUri(database.Id, tripContainer.Id, trip.Id).ToString(),
                                                                                new PartitionKey(trip.Title));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ItemResponse<Trip> tripResponse = await this.tripContainer.CreateItemAsync<Trip>(trip, new PartitionKey(trip.Title));
            }
        }

        public async Task AddEventToContainerAsync(Trip trip, Event eventObj)
        {
            eventObj.TripId = trip.Id;
            await UpdateEventInTripAsync(trip, eventObj.Id);

            try
            {
                ItemResponse<Event> eventResponse = await this.eventContainer.ReadItemAsync<Event>(eventObj.Id, new PartitionKey(eventObj.Name));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ItemResponse<Event> eventResponse = await this.eventContainer.CreateItemAsync<Event>(eventObj, new PartitionKey(eventObj.Name));
            }
        }

        public async Task UpdateEventAsync(Event eventObj)
        {
            await eventContainer.ReplaceItemAsync<Event>(eventObj, UriFactory.CreateDocumentUri(database.Id, eventContainer.Id, eventObj.Id).ToString(), new PartitionKey(eventObj.Name));
        }

        public async Task UpdateEventInTripAsync(Trip trip, string eventId)
        {
            trip.EventIds.Add(eventId);
            await tripContainer.ReplaceItemAsync<Trip>(trip, UriFactory.CreateDocumentUri(database.Id, tripContainer.Id, trip.Id).ToString(), new PartitionKey(trip.Title));
        }

        public async Task<Trip> GetTripByIdAsync(string tripId, string title)
        {
            return await this.tripContainer.ReadItemAsync<Trip>(UriFactory.CreateDocumentUri(database.Id, tripContainer.Id, tripId).ToString(), new PartitionKey(title));
        }
    }
}
