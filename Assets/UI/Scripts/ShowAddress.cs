// GetWalletAddress.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// use web3.jslib
using System.Runtime.InteropServices;
using TMPro;

public class ShowAddress : MonoBehaviour
{
    // text in the button
    public TextMeshProUGUI ButtonText;
    // use WalletAddress function from web3.jslib
    [DllImport("__Internal")] private static extern string WalletAddress();

    public void OnClickShowAddress()
    {
        // get wallet address and display it on the button
        ButtonText.text = WalletAddress();
    }
}