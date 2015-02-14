using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class DunegeonClasher : PhysicsGame
{
    PhysicsObject pelaaja1;
    public override void Begin()
    {
        // TODO: Kirjoita ohjelmakoodisi tähän

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");



        pelaaja1 = new PhysicsObject(40, 40);
        Add(pelaaja1);

        Keyboard.Listen(Key.Left, ButtonState.Down, LiikutaPelaajaa, null, new Vector(-50, 0));
        Keyboard.Listen(Key.Right, ButtonState.Down, LiikutaPelaajaa, null, new Vector(50, 0));
        Keyboard.Listen(Key.Up, ButtonState.Down, LiikutaPelaajaa, null, new Vector(0, 50));
        Keyboard.Listen(Key.Down, ButtonState.Down,LiikutaPelaajaa, null, new Vector(0, -50));
       
    }
        void LiikutaPelaajaa(Vector vektori)
        {
            pelaaja1.Push(vektori);
        }
}