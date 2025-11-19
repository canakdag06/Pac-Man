using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<Pellet> OnPelletEaten;

    // Invoke Functions (not necessary but looks good)
    public static void PelletEaten(Pellet pellet)
    {
        OnPelletEaten?.Invoke(pellet);
    }
}
