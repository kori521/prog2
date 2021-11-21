package com.company;

import java.util.Scanner;

public class UserInput extends Calculation
{
    public int inputN;
    public void Read()
    {
        Scanner in = new Scanner(System.in);
        System.out.print("Please Enter an Integer: ");
        int input = in.nextInt();
        System.out.println(input);
        if(input < 0) {
            do {
                System.out.flush();
                System.out.println("Please enter a positive number!");
                System.out.print("Please Enter an Integer: ");
                input = in.nextInt();
            }
            while(input < 0);
        }
        in.close();
        inputN = input;
        Calculation calculation = new Calculation();
        calculation.calc(inputN);
    }
}
