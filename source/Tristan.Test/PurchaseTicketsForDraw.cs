using System;
using fitlibrary;
using fitSharp.Fit.Engine;

namespace Tristan.Test {
    public class PurchaseTicketsForDraw: SetUpFixture {
        public void PlayerNumbersCount(string name, int[] numbers, int count) {
            var defaultDrawDate = GetArgumentInput<DateTime>(0);
            PlayerDrawNumbersCount(name, defaultDrawDate, numbers, count);
        }

        public void PlayerDrawNumbersCount(string userName, DateTime drawDate, int[] numbers, int count) {
            var playerService = Processor.GetSystemUnderTest<PlayerService>();
            playerService.PurchaseTicket(drawDate, userName, numbers, count);
        }
    }
}
