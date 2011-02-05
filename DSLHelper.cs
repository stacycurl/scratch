namespace DSLCombinators
{
  public abstract class Capturer<From, To>
  {
    protected readonly Func<From, To> pipeline;
    
    protected Capturer(Func<From, To> pipeline)
    {
      this.pipeline = pipeline
    }
  }
  
  public class NameCapturer<N, T> : Capturer<N, T>
  {
    public NameCapturer(Func<N, T> pipeline) : base(pipeline) {}
    public T WithName(N name) { return pipeline(name); }
  }
  
  public class AgeCapturer<A, T> : Capturer<A, T>
  {
    public AgeCapturer(Func<A, T> pipeline) : base(pipeline) {}
    public T WithAge(A age) { return pipeline(age); }
  }
  
  public class DSLHelper
  {
    public AgeCapturer<A, T> AgeCapturer<A, T>(Func<A, T> pipeline)
    {
      return new AgeCapturer<A, T>(pipeline);
    }

    public NameCapturer<N, T> NameCapturer<N, T>(Func<N, T> pipeline)
    {
      return new NameCapturer<N, T>(pipeline);
    }
  }
}