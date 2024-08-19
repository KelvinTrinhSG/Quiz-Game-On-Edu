using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.UI;

public class NFTMinting : MonoBehaviour
{
    private ThirdwebSDK sdk;
    public Text ERC721TokenBalanceTxt;
    private string nftContractAddress = "0xBBaddE8CDfCd0dB0aff1bEd0dE60be32805877d6";
    public Button nftClaimBtn;
    public Text ClaimNFTBtnTxt;
    // Start is called before the first frame update
    void Start()
    {
        sdk = ThirdwebManager.Instance.SDK;
        GetNFTBalance();
        nftClaimBtn.gameObject.SetActive(true);
        nftClaimBtn.interactable = true;
        ClaimNFTBtnTxt.text = "Claim NFT Certificate!";
    }

    public async void GetNFTBalance() {
        string address = await sdk.Wallet.GetAddress();
        Contract contract = sdk.GetContract(nftContractAddress);
        List<NFT> nftList = await contract.ERC721.GetOwned(address);
        if (nftList.Count > 0)
        {
            ERC721TokenBalanceTxt.text = "NFT Certificate Owned: " + nftList.Count;
        }
        else {
            ERC721TokenBalanceTxt.text = "NFT Certificate Owned: 0";
        }
    }

    public async void ClaimNFT() {
        Debug.Log("Claiming NFT ...");
        nftClaimBtn.interactable = false;
        ClaimNFTBtnTxt.text = "Claiming!";
        Contract contract = sdk.GetContract(nftContractAddress);
        var data = await contract.ERC721.Claim(1);
        Debug.Log("NFT claimed! ...");
        ClaimNFTBtnTxt.text = "Claimed!";
        GetNFTBalance();
    }
}
