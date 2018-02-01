﻿using System.Security.Cryptography;
using LifeX.API.Agent;

namespace LifeX.Client.Interfaces
{
    public interface ISimulation
    {

        /// <summary>
        /// Initializes the simulation without starting it yet
        /// </summary>
        void Initialize(/*Todo Add SimulationConfig object!*/);
        
        /// <summary>
        /// Initializes and Starts the simulation
        /// </summary>
        void Start();
    
        /// <summary>
        /// Stops the simulatio gracefully. This means
        /// it finishes the current tick and writes out all results
        /// </summary>
        void Stop();

        /// <summary>
        /// Pauses the simulation at the next possibility
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes a paused simulation. Will not do anything if the simulatiomn
        /// was not paused before
        /// </summary>
        void Resume();
    }
}