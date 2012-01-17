using System;
using System.Collections.Generic;

namespace Tristan {
    public static class Enumerable {
        public static void ForFirst<T>(this IEnumerable<T> collection, Action<T> firstAction, Action noneAction) {
            foreach (var item in collection) {
                firstAction(item);
                return;
            }
            noneAction();
        }

        public static R ForFirst<T,R>(this IEnumerable<T> collection, Func<T, R> firstAction, Func<R> noneAction) {
            foreach (var item in collection) {
                return firstAction(item);
            }
            return noneAction();
        }
    }
}
