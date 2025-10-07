using System;
using System.Collections.Generic;
using System.Linq;

namespace SingSong.App
{
    public class SongGenerator
    {
        private readonly string[] _animals;
        private readonly string[] _descriptions = {
            "I don't know why she swallowed a {0} - perhaps she'll die!",
            "That wriggled and wiggled and tickled inside her.",
            "How absurd to swallow a {0}.",
            "Fancy that to swallow a {0}!",
            "What a hog, to swallow a {0}!",
            "I don't know how she swallowed a {0}!"
        };

        public SongGenerator(string[] animals)
        {
            _animals = animals ?? throw new ArgumentNullException(nameof(animals));
        }

        public string GenerateVerse(int verseNumber)
        {
            if (verseNumber < 1 || verseNumber > _animals.Length)
                throw new ArgumentOutOfRangeException(nameof(verseNumber));

            var animal = _animals[verseNumber - 1];
            var result = $"There was an old lady who swallowed a {animal}.";

            if (verseNumber == 1)
            {
                result += $"\n{string.Format(_descriptions[0], animal)}";
            }
            else
            {
                // Agregar descripción específica del animal
                var descriptionIndex = Math.Min(verseNumber - 1, _descriptions.Length - 1);
                if (descriptionIndex == 1) // spider
                {
                    result += $"\n{_descriptions[1]}";
                }
                else
                {
                    result += $"\n{string.Format(_descriptions[descriptionIndex], animal)}";
                }

                // Agregar cadena de animales tragados
                for (int i = verseNumber - 1; i >= 1; i--)
                {
                    var currentAnimal = _animals[i];
                    var previousAnimal = _animals[i - 1];
                    result += $"\nShe swallowed the {currentAnimal} to catch the {previousAnimal}";
                    if (i > 1)
                    {
                        result += ",";
                    }
                    else
                    {
                        result += ";";
                    }
                }

                // Agregar el final
                result += $"\n{string.Format(_descriptions[0], _animals[0])}";
            }

            return result;
        }

        public string GenerateCompleteSong()
        {
            var verses = new List<string>();
            
            for (int i = 1; i <= _animals.Length; i++)
            {
                verses.Add(GenerateVerse(i));
                if (i < _animals.Length)
                {
                    verses.Add(""); // Línea en blanco entre versos
                }
            }

            // Agregar el verso final de muerte
            if (_animals.Length > 0)
            {
                verses.Add($"There was an old lady who swallowed a {_animals.Last()}...");
                verses.Add("...She's dead, of course!");
            }

            return string.Join("\n", verses);
        }
    }
}