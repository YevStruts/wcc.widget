﻿using Raven.Client.Documents;

namespace wcc.widget.data
{
    // 'DocumentStore' is a main-entry point for client API.
    // It is responsible for managing and establishing connections
    // between your application and RavenDB server/cluster
    // and is capable of working with multiple databases at once.
    // Due to it's nature, it is recommended to have only one
    // singleton instance per application
    public static class DocumentStoreHolder
    {
        private static string? _connectionString;
        public static void Init(string connectionString)
        {
            _connectionString = connectionString;
        }

        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Urls = new[] { _connectionString },
                    Database = "wcc.widget"
                };

                return store.Initialize();
            });

        internal static IDocumentStore Store => LazyStore.Value;
    }
}
