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

# How to start
Download the most recent release version [here](https://github.com/ptedeschi/NFT.net/releases) and execute it.
> Despite the fact that it was thought to work cross-platform, the WinForms application in .NET Core seems to rely solely on Windows at the moment. If there is interest from the community, we can consider alternative solutions to allow use on other platforms.

> The release already includes the .NET Runtime but if needed, you can find it [here](https://dotnet.microsoft.com/download/dotnet/5.0/runtime?initial-os=windows)

# How it works
Once you run the tool, you will need to select the folder where the NFT layers are located. Next, you will need to provide the output folder where the generated images and metadata will be saved.

After that, you can press the Generate button or you can customize some settings such as the Collection Size, Initial numbers, filename prefix etc.

![enter image description here](https://user-images.githubusercontent.com/6684508/133380651-e08d5972-9897-4095-9d0d-e8da84164b8d.PNG)

The most important thing to note here is to make sure you are using the tool, respecting some rules for the layer and elements:

#### Layer naming (*trait types*)
Layer folder names MUST start with a number, representing the order in which the image will be rendered, followed by a separator - (dash) plus the layer name.
For example:
 - 01-background
 - 02-shape
 - 03-letter
 
> Try to use a good name for your layers because this name will be used to fill in the Metadata *trait_type* value

#### Layer elements (*trait values*)
All images used to create the NFT MUST have the same dimensions (width and height). Subfolders are not supported.

If you want to add weighting ability to your images, you can do so by adding weight as a suffix to the image filename.

Imagine the scenario where you have a hat layer and support 5 different hat colors.
This is how you can weigh them:

 - hat_red+1.png
-  hat_orange+3.png
-  hat_yellow+3.png
-  hat_green+4.png
-  hat_blue+4.png

By using the plus sign (+) and a number, you are telling NFT<area>.net the chances to choose images.

In this case, red has 20% (1/5).
Orange and yellow have 60% (3/5).
And green and blue have 80% (4/5).

> If no weight is defined in the suffix, the total number of files present in the layers folder will be used as weight so that in the end the result is 100%

# Projects
- [Il Pinguino](https://opensea.io/collection/ilpinguino)
- [Rosquillas](https://opensea.io/collection/rosquillas)
> If you used NFT<area>.net to generate your NFT collection, please, get in touch.
I would love to add yours projects to this list.

# Support

I sincerely hope this tool can be useful for you.
I will be honored to know that I was able to contribute back to this community.

If you would like to support this work, you can send ETH or NFTs to me. The Ethereum (ERC20) wallet address for this project is: `0x893615196509526dbf85428d284658d12a6dc773`

**NFT<area>.net**  
*simple but sweet*