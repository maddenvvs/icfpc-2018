﻿using System;
using TraceOptimizer.Domain;
using TraceOptimizer.Optimization;
using TraceOptimizer.Optimization.Construct;

namespace TraceOptimizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelProvider = new Model3DFromStdinProvider();

            BotProgram program;
            var action = args[0];
            switch (action)
            {
                case "construct":
                    var modelToConstruct = modelProvider.GetModel();
                    // var constructor = new ConstructOptimizerV1();
                    var constructor = new ConstructOptimizerV2();
                    program = constructor.Optimize(modelToConstruct);
                    break;

                case "deconstruct":
                    var modelToDeconstruct = modelProvider.GetModel();
                    var deconstructor = new DeconstructOptimizerV1();
                    program = deconstructor.Optimize(modelToDeconstruct);
                    break;

                case "reconstruct":
                    var fromModel = modelProvider.GetModel();

                    // TODO: temporary hack
                    Console.ReadLine();

                    var toModel = modelProvider.GetModel();
                    var reconstructor = new ReconstructOptimizerV1();
                    program = reconstructor.Optimize(fromModel, toModel);
                    break;


                default:
                    Console.WriteLine($"Unsupported parameter: {action}");
                    return;
            }

            var serializer = new BotProgramToStdoutSerializer();
            serializer.Serialize(program);
        }
    }
}
