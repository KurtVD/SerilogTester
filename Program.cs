using Serilog;
using System;

namespace SerilogTester
{
    class Program
    {
        private static readonly string logFile = $"{AppDomain.CurrentDomain.BaseDirectory}/serilog.log";

        static void Main(string[] args)
        {
            // JSON value:
            // {
            //  "event_location": "home",
            //  "channel": "www",
            //  "user_id": "00000000-0000-0000-0000-000000000000",
            //  "login_id": null,
            //  "brand": "myBrand",
            //  "lists": [
            //    {
            //      "list_name": "myList",
            //      "list_size": 10,
            //      "limit": 10,
            //      "constraints": [
            //        {
            //          "query": {
            //            "key": "item_type",
            //            "match": {
            //              "value": "myValue"
            //            }
            //          }
            //        }
            //      ]
            //    }
            //  ],
            //  "request_id": "11111111-1111-1111-1111-111111111111",
            //  "version": "1"
            // }

            var json = "\"{\"event_location\":\"home\",\"channel\":\"www\",\"user_id\":\"00000000-0000-0000-0000-000000000000\",\"login_id\":null,\"brand\":\"myBrand\",\"lists\":[{\"list_name\":\"myList\",\"list_size\":10,\"limit\":10,\"constraints\":[{\"query\":{\"key\":\"item_type\",\"match\":{\"value\":\"myValue\"}}}]}],\"request_id\":\"11111111-1111-1111-1111-111111111111\",\"version\":\"1\"}\"";

            using (var log = new LoggerConfiguration()
                                    .WriteTo.File(logFile)
                                    .CreateLogger())
            {
                log.Information($"JSON = {json}");
            }

            // Serilog output value:
            // {
            //  "event_location": "home",
            //  "channel": "www",
            //  "user_id": "00000000-0000-0000-0000-000000000000",
            //  "login_id": null,
            //  "brand": "myBrand",
            //  "lists": [
            //    {
            //      "list_name": "myList",
            //      "list_size": 10,
            //      "limit": 10,
            //      "constraints": [
            //        {
            //          "query": {
            //            "key": "item_type",
            //            "match": {
            //              "value": "myValue"
            //            }
            //          }
            //         <----------- MISSING CLOSING BRACKET HERE <-----------
            //      ]
            //    }
            //  ],
            //  "request_id": "11111111-1111-1111-1111-111111111111",
            //  "version": "1"
            // }
        }
    }
}
