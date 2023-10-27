using TemaShopping.Models;
using System;
using System.Collections.Generic;
using TemaShopping.Commands;
using TemaShopping.Workflow;

namespace TemaShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderInfos = ReadorderInfos();
            var address = ReadValue("Address: ");
            Command command = new(orderInfos, address);
            OrderedWorkflow workflow = new OrderedWorkflow();
            var result = workflow.Execute(command);

            result.Match(
                    whenFailedEvent: @event =>
                    {
                        Console.WriteLine($"Publish failed: {@event.Reason}");
                        return @event;
                    },
                    whenSucceededEvent: @event =>
                    {
                        Console.WriteLine($"Publish succeeded.");
                        Console.WriteLine(@event.Csv);
                        Console.WriteLine($"Total Price: {@event.Price}");
                        return @event;
                    }
                );
        }

        private static List<UnvalidatedOrderInfo> ReadorderInfos()
        {
            List<UnvalidatedOrderInfo> orderInfos = new();
            do
            {
                //read registration number and grade and create a list of greads
                var productNumber = ReadValue("ProductNumber: ");
                if (string.IsNullOrEmpty(productNumber))
                {
                    break;
                }

                var quantity = ReadValue("Quantity: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                orderInfos.Add(new(productNumber, quantity));
            } while (true);
            return orderInfos;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
