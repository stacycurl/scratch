using System;

using DSLCombinators;

namespace Cars
{
  public interface Car
  {
    void Drive();
  }
  
  public class FastCar : Car
  {
    private readonly double acceleration;
    private readonly string name;
    private readonly int age;
    
    public FastCar(double acceleration, string name, int age)
    {
      this.acceleration = acceleration;
      this.name = name;
      this.age = age;
    }
    
    public void Drive()
    {
      Console.WriteLine("FastCar (Name: {0}, Age: {1}, Acceleration: {2})",
        name, age, acceleration);
    }
  }
  
  public class CheapCar : Car
  {
    private readonly int milesPerGallon;
    private readonly string name;
    private readonly int age;
    
    public CheapCar(int milesPerGallon, string name, int age)
    {
      this.acceleration = acceleration;
      this.name = name;
      this.age = age;
    }
    
    public void Drive()
    {
      Console.WriteLine("CheapCar (Name: {0}, Age: {1}, Miles Per Gallon: {2})",
        name, age, milesPerGallon);
    }
  }
  
  public class CarFactory : DSLHelper
  {
    public NameCapturer<AgeCapturer<FastCar>> FastCar(double acceleration)
    {
      return NameCapturer(name => AgeCapturer(age => new FastCar(acceleration, name, age)));
    }
    
    public NameCapturer<AgeCapturer<CheapCar>> CheapCar(int milesPerGallon)
    {
      return NameCapturer(name => AgeCapturer(age => new CheapCar(milesPerGallon, name, age)));
    }
  }
}