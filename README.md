# CC3-Rokoko-Unity-integration
A few scripts to use 3D characters made with Reallusion Character Creator 3 along with Rokoko facial motion capture inside Unity

## Fatures
- Rotate eyes transform according to the blendshapes values using the CC3+ naming convention
- Remap Rokoko blendshape names to CC3+ in live stream

## Usage

#### RotateBonesByBlendhsapes.cs
Just add the script to CC_Base_Body in your CC3+ character and link the CC_Base_L_Eye, CC_Base_R_Eye and CC_Base_Jawroot transforms in the inspector. This script uses twelve different blendshapes to rotate eyes and jaw according to the blendshape values. Remeber you need to remap your Rokoko animations using this tool: https://github.com/chr33z/unity-blendshape-mapper

#### CC3Face.cs
This class overrides the one from https://github.com/Rokoko/rokoko-studio-live-unity to remap blendshape names without the need to manually type blendshape mapping. Add this script instead fo Face.cs to CC_Base_Body and follow the guidelines from Rokoko.
> Note: you need to edit the parent Face class to allow overriding of the Start and UpdateFace methods. 
- *protected virtual void Start...*
- *public virtual void UpdateFace...*

### CopyBlendshapes.cs
This class copies blendshape values from a source SkinnedMeshRenderer to a second one. Useful if you have secondary meshes like eyebrows or beard that need to be animated indipendently

### BlendshapeEmphasis.cs
This class lets you fine tune the sensitivity of your blendshape animations on a given charater. 

##

#### Authors
These script were developed by Game Maker Academy (Italy) while experimenting the best practices and refining the pipeline for using characters from Character Creator 3 (Reallusion) and Rokoko face capture system insede the Unity game engine
Feel free to contact us on the following social media
- Facebook: @gamemakeracademy
- Instagram: @gamemakeracademy

#### Disclaimer 
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#### License
https://www.gnu.org/licenses/lgpl-3.0.en.html

