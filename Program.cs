﻿using System;
public class Show
{
    private double price;
    public double Price { get { return price; } }
    private int tickets;

    public Show()
    {
        price = 100;
        tickets = 1000;
    }
    public Show(double p, int t)
    {
        price = p;
        tickets = t;
    }
    public void Init(double p, int t)
    {
        price = p;
        tickets = t;
    }
    public void Display()
    {
        Console.WriteLine("Цена: " + price + "; Количество: " + tickets);
    }
    public double Income()
    {
        return price * tickets;
    }
}

public class Theatre
{
    private Show[] shows = new Show[3];

    private int[] Fullness = new int[3];

    public Theatre()
    {
        for (int i = 0; i < shows.Length; i++)
        {
            shows[i] = new Show();
            Fullness[i] = i * 200;
        }
    }
    public Theatre(int[] s, double[] p, int[] t)
    {
        for (int i = 0; i < shows.Length; i++)
        {
            shows[i] = new Show(p[i], t[i]);
            Fullness[i] = s[i];
        }
    }
    public void Init(int[] s, double[] p, int[] t)
    {
        for (int i = 0; i < shows.Length; i++)
        {
            shows[i] = new Show(p[i], t[i]);
            Fullness[i] = s[i];
        }
    }
    public void Display()
    {
        for (int i = 0; i < shows.Length; i++)
        {
            shows[i].Display();
            Console.WriteLine("Проданные билеты: " + Fullness[i]);
        }
    }
    public double Income()
    {
        double sum = 0;
        for (int i = 0; i < shows.Length; i++)
        {
            sum += shows[i].Price * Fullness[i];
        }
        return sum;
    }
    public Show BadShow()
    {
        Show bad = new Show(0, 0);
        bad = shows[0];
        for (int i = 0; i < shows.Length; i++)
        {
            if (bad.Income() > shows[i].Income())
                bad = shows[i];
        }
        return bad;
    }
}

public class ShowFabric     //фабричный метод
{
    public Show CreateShow(double p, int t)
    {
        return new Show(p, t); //new создаются не в main
    }
}

public class TheatreFabric  //фабричный метод
{
    public Theatre CreateTheatre(int[] s, double[] p, int[] t)
    {
        return new Theatre(s, p, t);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        ShowFabric showFabric = new ShowFabric();    //создание фабрики
        Show show = showFabric.CreateShow(100, 1000);  //создание объекта через фабрику
        double res;
        show.Display();
        res = show.Income();
        Console.WriteLine("Прибыль со спектакля: " + res);
        double[] p = new double[] { 100, 200, 500 }; //Цена билета на каждый спектакль
        int[] t = new int[] { 1000, 1000, 1000 }; //Максимальная вместимость 
        int[] s = new int[] { 200, 500, 700 }; //Заполненность
        TheatreFabric theatreFabric = new TheatreFabric();
        Theatre theatre = theatreFabric.CreateTheatre(s, p, t);
        theatre.Display();
        res = theatre.Income();
        Console.WriteLine();
        Console.WriteLine("Сумма от всех продаж: " + res);
        Console.ReadKey();
    }
}