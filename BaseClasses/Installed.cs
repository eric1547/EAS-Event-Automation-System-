    // This little mess is so I can store the JSON obj as an obj that I can use. (IT PISSES ME OFF)
    public class Installed
    {
        // The required modfier basicly makes the var to be requaired (wow, who expected).
        // But, for function, it mainly make things .. not yelow
        public required ClientObj installed {get; set;}
        public class ClientObj
        {
            public required string client_secret {get; set;}
            public required string client_id {get; set;}
        };   
    };
