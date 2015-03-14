using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class DunegeonClasher : PhysicsGame
{
    Image taustaKuva = LoadImage("Level1Background");
    Image palikkanKuva = LoadImage("GameTile");

    PhysicsObject pelaaja1;

    public override void Begin()
    {
        SetWindowSize(1024, 768, false);
        {
            Gravity = new Vector(0.0, -75.0);
            TileMap kentta = TileMap.FromLevelAsset("kentta1");
            kentta.SetTileMethod('=', LisaaPalikka, Color.White);
            kentta.SetTileMethod('p', LisaaNullPalikka, Color.Transparent);
            kentta.SetTileMethod('t', LisaaOlio1, Color.Red);


            Level.Background.Image = taustaKuva;


            kentta.Execute(55, 55);

        }

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");




        pelaaja1 = new PhysicsObject(75, 75);
        pelaaja1.LinearDamping = 0.95;
        pelaaja1.Mass = 1.05;
        Add(pelaaja1);



        Keyboard.Listen(Key.Left, ButtonState.Down, LiikutaPelaajaa, null, new Vector(-150, 0));
        Keyboard.Listen(Key.Right, ButtonState.Down, LiikutaPelaajaa, null, new Vector(150, 0));
        Keyboard.Listen(Key.Up, ButtonState.Down, LiikutaPelaajaa, null, new Vector(0, 150));
        Keyboard.Listen(Key.Down, ButtonState.Down, LiikutaPelaajaa, null, new Vector(0, -150));

    }
    void LiikutaPelaajaa(Vector vektori)
    {
        pelaaja1.Push(vektori);
    }


    void LisaaPalikka(Vector paikka, double leveys, double korkeus, Color white)
    {
        PhysicsObject palikka = PhysicsObject.CreateStaticObject(512, 16);
        palikka.Position = paikka;
        palikka.Image = palikkanKuva;
        Add(palikka);

    }
    void LisaaNullPalikka(Vector paikka, double leveys, double korkeus, Color white)
    {
        PhysicsObject NullPalikka = PhysicsObject.CreateStaticObject(16, 16);
        NullPalikka.Position = paikka;
        NullPalikka.Color = Color.Transparent;
        Add(NullPalikka);
    }
    void LisaaOlio1(Vector paikka, double leveys, double korkeus, Color Red)
    {

        PhysicsObject Olio1 = new PhysicsObject(90, 90);
        Olio1.Position = paikka;
        Olio1.Color = Color.Red;
        Add(Olio1);
       
        PathFollowerBrain polkuAivot = new PathFollowerBrain(200);
        List<Vector> polku = new List<Vector>();
        polkuAivot.Active = true;
        polku.Add(new Vector(-50, -100));
        polku.Add(new Vector(-100, -50));
        polku.Add(new Vector(-250, -200));
  
        polkuAivot.Path = polku;
        polkuAivot.Loop = true;
        polkuAivot.Speed = 100;

    }
}





