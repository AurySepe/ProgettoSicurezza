public class PokeChain
{
    public PokeChainData Data { get; private set; }

    public bool Gender { get; set; }


    public PokeChain(PokeChainData data, bool gender)
    {
        Data = data;
        Gender = gender;
    }
}