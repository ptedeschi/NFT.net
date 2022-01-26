// <copyright file="WeightedRandomizer.cs" company="Tedeschi">
// Copyright (c) Tedeschi. All rights reserved.
// </copyright>
namespace Tedeschi.NFT.Mechanism
{
    using System;
    using Weighted_Randomizer;

    public class WeightedRandomizer<T>
        where T : IComparable<T>
    {
        private readonly DynamicWeightedRandomizer<T> randomizer = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightedRandomizer{T}"/> class.
        /// </summary>
        public WeightedRandomizer()
        {
            this.randomizer = new DynamicWeightedRandomizer<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightedRandomizer{T}"/> class with the given seed.
        /// </summary>
        /// <param name="seed">The seed value to initialize the random number generator.</param>
        public WeightedRandomizer(int seed)
        {
            this.randomizer = new DynamicWeightedRandomizer<T>(seed);
        }

        /// <summary>
        /// Adds the given item with the given weight. Higher weights are more likely to be chosen.
        /// </summary>
        /// <param name="key">The item key to add.</param>
        /// <param name="weight">The given weight to use.</param>
        public void Add(T key, int weight)
        {
            this.randomizer.Add(key, weight);
        }

        /// <summary>
        /// Returns an item chosen randomly by weight (higher weights are more likely).
        /// </summary>
        /// <returns>The choosen item.</returns>
        public T Select()
        {
            return this.randomizer.NextWithReplacement();
        }
    }
}
