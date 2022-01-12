using System;
using System.Collections.Generic;

namespace AllergyScore
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        private readonly Allergens allergy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException("Thrown when score is less than zero.", nameof(score));
            }

            this.allergy = (Allergens)score;
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            return this.allergy.HasFlag(allergens);
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            var allergensList = new List<Allergens>();
            foreach (Allergens value in Enum.GetValues(this.allergy.GetType()))
            {
                if (this.allergy.HasFlag(value))
                {
                    allergensList.Add(value);
                }
            }

            return allergensList.ToArray();
        }
    }
}
