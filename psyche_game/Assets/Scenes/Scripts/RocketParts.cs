using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * From top to bottom here are some potential rocket parts:
 * Automatic Control gyros (guidance)
 * Guiding beam and radio control gear                                   INSTRUMENT SECTION
 * 
 * Alcohol/water mixture tank                                           FUEL TANK SECTION
 *  
 * Liquid oxygen tank                                                           |
 *                                                                              |
 * turbo fuel pump | hydrogen peroxide container 
 * 
 * 
 * Oxygen valve
 * 
 * Combustion chamber                                                          TAIL SECTION
 * 
 * Main Alcohol Valve
 * 
 * (Very bottom of rocket): Gas Rudder | Air Rudder | Antenna 
 * 
 * 
 * 
 * 
 * I think for the components we should just simplify and not get into the specifics, Generally speaking we should have a simple and an advanced version of each, and the player must pick 2 advanced and 2 simple
 * for example, to be able to launch the spaceship by the deadline.
 * 
 * For Instrument section:
 * Simple instrument section has one of: 1) slightly more latency when controlling the spacecraft in the flight phase 2) we use some kind of visual degredation technique on ocassion (screen goes fuzzy, for example)
 * Advanced instrument section has neither of those tradeoffs but costs significantly longer.
 * 
 * For the Fuel Tank Section:
 * Simple fuel tank: burns hotter and as a result the spacecraft when jettisoned into space starts with less "health"
 * Advanced fuel tank: no tradeoffs, but again takes longer.
 * 
 * For the Tail Section:
 * Simple Tail Section: Worse control during launch phase results in slightly off trajectory path from the start and lower starting velocity
 * 
 * 
 */


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
