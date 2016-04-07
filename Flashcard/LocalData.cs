using System;
using Flashcard.Model;
using System.Collections.Generic;
namespace Flashcard
{
    public class LocalData
    {
        private static LocalData instance;

        public Quiz Quiz { get; set; }

        private LocalData()
        {
            Quiz = new Quiz(true);
        }
        public static LocalData Instance
        {
            get {
                if (instance == null)
                    instance = new LocalData();
                return instance;
            }
        }
    }
}

