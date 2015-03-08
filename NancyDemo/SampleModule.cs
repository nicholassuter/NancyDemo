namespace NancyDemo
{
    public class SampleModule : Nancy.NancyModule
    {
        public SampleModule() : base("/sample")
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}
