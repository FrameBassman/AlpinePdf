using System;

namespace AlpinePdf.Test
{
    public class Environment
    {
        public Uri ApplicationUrl()
        {
            return new Uri($"http://{DockerHost()}:5000/pdf");
        }

        private String DockerHost()
        {
            var variable = System.Environment.GetEnvironmentVariable("DOCKER_HOST");
            if (String.IsNullOrEmpty(variable))
            {
                return "localhost";
            }
            else
            {
                return new UriBuilder(variable).Host;
            }
        }
    }
}