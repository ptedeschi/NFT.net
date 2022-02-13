# Welcome to NFT<area>.net!

It all started during the creation of the [Il Pinguino Collection](https://opensea.io/collection/ilpinguino), our first step towards an immersion in the world of Non-Fungible Token (NFT).

We are learning more every day and the most pleasant surprise was getting to know the community behind this world. It's amazing to see the support from everyone involved.

That's why we decided to go a step further.
Knowing the community involvement in open source projects, we decided to contribute as well.

We are not artists, but we can help with our code.

There are many amazing projects that help in creating generative art, but they all require a certain technical aspect of making code modifications, installing dependencies, etc. This can end up inhibiting people who could be adding to this space but who are not comfortable in this world.

That's why we created the NFT<area>.net project.
An application developed with .NET Core to generate NFT's through a graphical interface. Simple as that, in the best Grab & Go style.

# Features

 - Multiple layers
 - Metadata generation (Individual and Merged)
 - Update Metadata Image Base URI after generation (perfect for Pinata IPFS)
 - Weighted Image Randomizer
 - No coding skills required
 - No ads

# How to start
Download the most recent release version [here](https://github.com/ptedeschi/NFT.net/releases) and execute it.
> Despite the fact that it was thought to work cross-platform, the WinForms application in .NET Core seems to rely solely on Windows at the moment. If there is interest from the community, we can consider alternative solutions to allow use on other platforms.

> The release already includes the .NET Runtime but if needed, you can find it [here](https://dotnet.microsoft.com/download/dotnet/5.0/runtime?initial-os=windows)

# How it works
Once you run the tool, you will need to select the folder where the NFT layers are located. Next, you will need to provide the output folder where the generated images and metadata will be saved.

After that, you can press the Generate button or you can customize some settings such as the Collection Size, Initial numbers, filename prefix etc.

![](https://user-images.githubusercontent.com/6684508/134297322-618b1a15-17f6-4683-b65f-afc415b87768.png)

The most important thing to note here is to make sure you are using the tool, respecting some rules for the layer and elements:

## Layer naming (*trait types*)
Layer folder names MUST start with a number, representing the order in which the image will be rendered, followed by a separator - (dash) plus the layer name.
For example:
 - 01-background
 - 02-shape
 - 03-letter
 
> Try to use a good name for your layers because this name will be used to fill in the Metadata *trait_type* value

## Layer elements (*trait values*)
All images used to create the NFT MUST have the same dimensions (width and height). Subfolders are not supported.

### Weighting
If you want to add weighting ability to your images, you can do so by adding weight as a suffix to the image filename.

Imagine the scenario where you have a hat layer and support 5 different hat colors.
This is how you can weigh them:

- hat_red+10.png
- hat_orange+20.png
- hat_yellow+20.png
- hat_green+40.png
- hat_blue.png

By using the plus sign (+) and a number (between 1-100), you are telling NFT<area>.net the chances to choose images.

In this case, red has 10%.
Orange and yellow have 20%.
Green has 40%.
And blue, since no suffix was added, will be treated as 100%.

> Currently, only integers numbers are supported for setting weights!

> If no weight is defined in the suffix, 100% is assumed by default!

A new tool was recently added so that you can get a better overview of the probabilities of your features.
You can access it by clicking Tools > Check Trait Weights

![](https://user-images.githubusercontent.com/6684508/134296171-dd9966f8-20ed-4311-9502-0e16d0eb5c9e.png)

# Projects
- [Il Pinguino](https://opensea.io/collection/ilpinguino)  
![](https://lh3.googleusercontent.com/P6JybURJdbvL1QaMhIpGZJF4Hs5ypD3Sdq6ROErkbBZHkgGuTqNuibsXASi7affssffYU9BEXyKkS680qzLEzK6F-N6mqaGslJxQbx0=h600)

- [Rosquillas](https://opensea.io/collection/rosquillas)  
![](https://lh3.googleusercontent.com/Vdgy7zqiH64ezMOSx_uppYq1fTAtAsrrfQSYMuJ0ky07SmCOvEfkaMeZkfJJ575cqwd0VlxumTsFLUEAYefekDe3pCnTbcg1AmNPoQ=h600)

- [Monero Lisa Genesis](https://opensea.io/collection/monero-lisa-genesis)  
![](https://lh3.googleusercontent.com/xcytYnEuYaqeI0LSdyDviwOty-V1koW5RPJ_jObR23z1mEmN2k_Eu8Jxt-RzzLSAbz5gd_R4E5YyG0peBQF8rKznvlhxZsaV2VtcBA=h400)


> If you used NFT<area>.net to generate your NFT collection, please, get in touch.
I would love to add yours projects to this list.

# Support

I sincerely hope this tool can be useful for you.
I will be honored to know that I was able to contribute back to this community.

If you would like to support this work, you can send ETH or NFTs to me. The Ethereum (ERC20) wallet address for this project is: `0x893615196509526dbf85428d284658d12a6dc773`

**NFT<area>.net**  
*simple but sweet*
