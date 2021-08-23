﻿using Microsoft.Extensions.Logging;
using nestortodo.Functions.Functions;
using nestortodo.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace nestortodo.Test.Test
{
    public class ScheduleFunctionTest
    {
        [Fact]
        public void Schedulefunction_Should_Log_Message()
        {
            // Arrange
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);
            // Act
            ScheduleFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];

            // Asert
            Assert.Contains("Deleting completed", message);
        }
    }
}
