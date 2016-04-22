using System;

public class BirthdayArray : ArrayList
{
	public BirthdayArray()
	{
        super();
	}
    public void add() {
        //notify observers
        super.add();
    }
}
