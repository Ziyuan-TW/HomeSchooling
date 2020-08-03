using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HomeSchooling;
using Xunit;

namespace HomeSchoolingTest
{
    public class UnitTest1
    {
        [Fact]
        public void AssessTasksHandler_ShouldReturnEmptyArray_IfTasksLessThanThree()
        {
            var tasks = new Tuple<string, int>[]
            {
                Tuple.Create("A", 1),
                Tuple.Create("B", 1)
            };


            var handler = new AssessTasks();
            var result = handler.AssessTasksHandler(tasks);

            Assert.Equal(3, result.Length);
            Assert.Null(result[0]);
        }

        [Fact]
        public void AssessTasksHandler_ShouldReturnResult_IfHasThreeSameTasks()
        {
             var tasks = new Tuple<string, int>[]
            {
                Tuple.Create("A", 1),
                Tuple.Create("B", 1),
                Tuple.Create("C", 1)
            };
            var expectedResult = new Tuple<string, int>[3][]
            {
                new Tuple<string, int>[]{tasks[0]},
                new Tuple<string, int>[]{tasks[1]},
                new Tuple<string, int>[]{tasks[2]}
            };

            var handler = new AssessTasks();
            var result = handler.AssessTasksHandler(tasks);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void AssessTasksHandler_ShouldReturnEmptyArray_IfHasThreeDifferentPointTasks()
        {
             var tasks = new Tuple<string, int>[]
            {
                Tuple.Create("A", 1),
                Tuple.Create("B", 1),
                Tuple.Create("C", 2)
            };

            var handler = new AssessTasks();
            var result = handler.AssessTasksHandler(tasks);

            Assert.Equal(3, result.Length);
            Assert.Null(result[0]);
        }

        [Fact]
        public void AssessTasksHandler_ShouldReturnEmptyArray_IfTotalPointsCannotBeDividedByThree()
        {
             var tasks = new Tuple<string, int>[]
            {
                Tuple.Create("A", 2),
                Tuple.Create("B", 1),
                Tuple.Create("C", 2),
                Tuple.Create("D", 2)
            };

            var handler = new AssessTasks();
            var result = handler.AssessTasksHandler(tasks);

            Assert.Equal(3, result.Length);
            Assert.Equal(null, result[0]);
        }

        [Fact]
        public void AssessTasksHandler_ShouldReturnResult_IfTotalPointsCanBeDividedByThree()
        {
             var tasks = new Tuple<string, int>[]
            {
                Tuple.Create("A", 1),
                Tuple.Create("B", 1),
                Tuple.Create("C", 2),
                Tuple.Create("D", 2)
            };
            var expectedResult = new Tuple<string, int>[3][]{
                new Tuple<string, int>[]{
                    Tuple.Create("C", 2)
                },
                new Tuple<string, int>[]{
                    Tuple.Create("D", 2)
                },
                new Tuple<string, int>[]{
                    Tuple.Create("A", 1),
                    Tuple.Create("B", 1)
                }
            };

            var handler = new AssessTasks();
            var result = handler.AssessTasksHandler(tasks);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void AssessTasksHandler_ShouldReturnEmptyArray_IfTasksFailToBeSplited()
        {
             var tasks = new Tuple<string, int>[]
            {
                Tuple.Create("A", 4),
                Tuple.Create("B", 1),
                Tuple.Create("C", 2),
                Tuple.Create("D", 2)
            };

            var handler = new AssessTasks();
            var result = handler.AssessTasksHandler(tasks);

            Assert.Equal(3, result.Length);
            Assert.Null(result[0]);
        }


    }
}
