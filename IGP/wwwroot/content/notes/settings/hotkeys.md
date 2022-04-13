---
title: Custom HotKey Setup
summary: Customize your hotkeys in the pre-alpha.
created_date: 4/13/2022
updated_date: 4/13/2022
---

In the pre-alpha, IGP comes with some Unreal default hotkey setup.

This document will explain how to set up, modify, and use a new hotkey setup.

## Save the "Input.ini" file

***Copy the below content and save the file as `Input.ini`.***

```ini
[/Script/Engine.InputSettings]
ActionMappings=(ActionName="Ability1",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Q)
ActionMappings=(ActionName="Ability2",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=W)
ActionMappings=(ActionName="Ability3",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=E)
ActionMappings=(ActionName="Ability4",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=R)
ActionMappings=(ActionName="Ability5",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=F)
ActionMappings=(ActionName="Ability6",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=V)
ActionMappings=(ActionName="Ability7",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=A)
ActionMappings=(ActionName="Ability8",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=S)
ActionMappings=(ActionName="AttackMove",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=A)
ActionMappings=(ActionName="CancelOrders",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Tilde)
ActionMappings=(ActionName="CompleteAllTraining",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=I)
ActionMappings=(ActionName="CompleteConstructions",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=K)
ActionMappings=(ActionName="ConstructionTab",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=C)
ActionMappings=(ActionName="ControlGroup1",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=D)
ActionMappings=(ActionName="ControlGroup10",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Zero)
ActionMappings=(ActionName="ControlGroup2",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Two)
ActionMappings=(ActionName="ControlGroup3",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Three)
ActionMappings=(ActionName="ControlGroup4",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Four)
ActionMappings=(ActionName="ControlGroup5",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Five)
ActionMappings=(ActionName="ControlGroup6",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Six)
ActionMappings=(ActionName="ControlGroup7",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Seven)
ActionMappings=(ActionName="ControlGroup8",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Eight)
ActionMappings=(ActionName="ControlGroup9",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Nine)
ActionMappings=(ActionName="ControlGroupAddStealKey",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=SpaceBar)
ActionMappings=(ActionName="Delete",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Delete)
ActionMappings=(ActionName="DisableWeapons",bShift=True,bCtrl=False,bAlt=True,bCmd=False,Key=J)
ActionMappings=(ActionName="DownArrow",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Down)
ActionMappings=(ActionName="DragPan",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=MiddleMouseButton)
ActionMappings=(ActionName="Enter Cinematic Camera",bShift=True,bCtrl=False,bAlt=True,bCmd=False,Key=L)
ActionMappings=(ActionName="FullMana",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=J)
ActionMappings=(ActionName="FullyDamageSelectedUnits",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=P)
ActionMappings=(ActionName="GetAlloyEther",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=M)
ActionMappings=(ActionName="GetPyre",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=L)
ActionMappings=(ActionName="Hide HUD",bShift=True,bCtrl=False,bAlt=True,bCmd=False,Key=O)
ActionMappings=(ActionName="InclusiveSelect/QueueCommand",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=LeftShift)
ActionMappings=(ActionName="JumpToCameraLocation1",bShift=True,bCtrl=False,bAlt=False,bCmd=False,Key=Z)
ActionMappings=(ActionName="JumpToCameraLocation2",bShift=True,bCtrl=False,bAlt=False,bCmd=False,Key=X)
ActionMappings=(ActionName="JumpToCameraLocation3",bShift=True,bCtrl=False,bAlt=False,bCmd=False,Key=C)
ActionMappings=(ActionName="JumpToCameraLocation4",bShift=True,bCtrl=False,bAlt=False,bCmd=False,Key=V)
ActionMappings=(ActionName="JumpToCameraLocation5",bShift=True,bCtrl=False,bAlt=False,bCmd=False,Key=Two)
ActionMappings=(ActionName="JumpToCameraLocation6",bShift=True,bCtrl=False,bAlt=False,bCmd=False,Key=Three)
ActionMappings=(ActionName="JumpToCameraLocation7",bShift=True,bCtrl=False,bAlt=False,bCmd=False,Key=Four)
ActionMappings=(ActionName="LeftArrow",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Left)
ActionMappings=(ActionName="LeftMouseClick",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=LeftMouseButton)
ActionMappings=(ActionName="MarcoPolo",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Comma)
ActionMappings=(ActionName="Menu",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Escape)
ActionMappings=(ActionName="Menu",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=F10)
ActionMappings=(ActionName="MinimapJumpTo",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=LeftMouseButton)
ActionMappings=(ActionName="Move/ContextCommand",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=RightMouseButton)
ActionMappings=(ActionName="PyreTab",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=One)
ActionMappings=(ActionName="ResearchTab",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Tab)
ActionMappings=(ActionName="RespawnNeutrals",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=N)
ActionMappings=(ActionName="RightArrow",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Right)
ActionMappings=(ActionName="RightMouseClick",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=RightMouseButton)
ActionMappings=(ActionName="Select/ConfirmAbility",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=LeftMouseButton)
ActionMappings=(ActionName="SelectUnitProductionBuildings",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Z)
ActionMappings=(ActionName="SetCameraLocation1",bShift=False,bCtrl=True,bAlt=False,bCmd=False,Key=Z)
ActionMappings=(ActionName="SetCameraLocation2",bShift=False,bCtrl=True,bAlt=False,bCmd=False,Key=X)
ActionMappings=(ActionName="SetCameraLocation3",bShift=False,bCtrl=True,bAlt=False,bCmd=False,Key=C)
ActionMappings=(ActionName="SetCameraLocation4",bShift=False,bCtrl=True,bAlt=False,bCmd=False,Key=V)
ActionMappings=(ActionName="SetCameraLocation5",bShift=False,bCtrl=True,bAlt=False,bCmd=False,Key=Two)
ActionMappings=(ActionName="SetCameraLocation6",bShift=False,bCtrl=True,bAlt=False,bCmd=False,Key=Three)
ActionMappings=(ActionName="SetCameraLocation7",bShift=False,bCtrl=True,bAlt=False,bCmd=False,Key=Four)
ActionMappings=(ActionName="StandGround",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=S)
ActionMappings=(ActionName="SwitchAbilityCommandLayer",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=SpaceBar)
ActionMappings=(ActionName="TheCheatToRuleThemAll",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=None)
ActionMappings=(ActionName="Toggle Gamepad",bShift=False,bCtrl=True,bAlt=True,bCmd=False,Key=Slash)
ActionMappings=(ActionName="UpArrow",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=Up)
ActionMappings=(ActionName="ZoomIn",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=MouseScrollUp)
ActionMappings=(ActionName="ZoomOut",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=MouseScrollDown)
ActionMappings=(ActionName="UnitTypeSelectionModifier",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=LeftControl)
```
***Copy the above content and save the file as `Input.ini`.***

## Understand the Input.ini

You can notice a single line of this file can be broken down like this.

`ActionMappings=(ActionName="AttackMove",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=A)`
- `ActionMappings=(***)`: Indicates content is an action mapping. i.e. a hotkey
- `ActionName="AttackMove"`: Indicates the name of the selected action. Here, we are using the `AttackMove` move action, that forces your selected army to attack.
- `Key=A`: Indicates key being mapped to the action. Set to `Key=Tab` to require the Tab key to be pressed instead, to perform the `AttackMove` action.
  - `bShift=False`: Indicates that the Shift key is not held. Set to `bShift=True` to require a shift key held to perform the mapped action.
  - `bCtrl=False`: Indicates that the Ctrl key is not held. Set to `bCtrl=True` to require a ctrl key held to perform the mapped action.
  - `bAlt=False`: Indicates that the Alt key is not held. Set to `bAlt=True` to require a alt key held to perform the mapped action.
  - `bCmd=False`: Indicates that the Cmd key is not held. Set to `bCmd=True` to require a cmd key held to perform the mapped action. (Macs not supported by IGP)

## Modify the Input.ini file

You are now going to want to modify the file with your own hotkey setup.

To do this, replace any of the Key=`VALUE` mapped to the desired actions with any value from the list below.

*For example, you can swap the Z Key value in SelectUnitProductionBuildings to C. Which would look like this: `ActionMappings=(ActionName="SelectUnitProductionBuildings",bShift=False,bCtrl=False,bAlt=False,bCmd=False,Key=C)`*

**Key Values**
- `AnyKey`
- `MouseX`
- `MouseY`
- `Mouse2D`
- `MouseScrollUp`
- `MouseScrollDown`
- `MouseWheelAxis`
- `LeftMouseButton`
- `RightMouseButton`
- `MiddleMouseButton`
- `ThumbMouseButton`
- `ThumbMouseButton2`
- `BackSpace`
- `Tab`
- `Enter`
- `Pause`
- `CapsLock`
- `Escape`
- `SpaceBar`
- `PageUp`
- `PageDown`
- `End`
- `Home`
- `Left`
- `Up`
- `Right`
- `Down`
- `Insert`
- `Delete`
- `Zero`
- `One`
- `Two`
- `Three`
- `Four`
- `Five`
- `Six`
- `Seven`
- `Eight`
- `Nine`
- `A`
- `B`
- `C`
- `D`
- `E`
- `F`
- `G`
- `H`
- `I`
- `J`
- `K`
- `L`
- `M`
- `N`
- `O`
- `P`
- `Q`
- `R`
- `S`
- `T`
- `U`
- `V`
- `W`
- `X`
- `Y`
- `Z`
- `NumPadZero`
- `NumPadOne`
- `NumPadTwo`
- `NumPadThree`
- `NumPadFour`
- `NumPadFive`
- `NumPadSix`
- `NumPadSeven`
- `NumPadEight`
- `NumPadNine`
- `Multiply`
- `Add`
- `Subtract`
- `Decimal`
- `Divide`
- `F1`
- `F2`
- `F3`
- `F4`
- `F5`
- `F6`
- `F7`
- `F8`
- `F9`
- `F10`
- `F11`
- `F12`
- `NumLock`
- `ScrollLock`
- `LeftShift`
- `RightShift`
- `LeftControl`
- `RightControl`
- `LeftAlt`
- `RightAlt`
- `LeftCommand`
- `RightCommand`
- `Semicolon`
- `Equals`
- `Comma`
- `Underscore`
- `Hyphen`
- `Period`
- `Slash`
- `Tilde`
- `LeftBracket`
- `Backslash`
- `RightBracket`
- `Apostrophe`
- `Ampersand`
- `Asterix`
- `Caret`
- `Colon`
- `Dollar`
- `Exclamation`
- `LeftParantheses`
- `RightParantheses`
- `Quote`
- `A_AccentGrave`
- `E_AccentGrave`
- `E_AccentAigu`
- `C_Cedille`
- `Section`

# Transfer the Input.ini file

Drag and drop this new `Input.ini` file into `WindowsClient` folder in IGP. This folder can be found under `C:\Users\YOUR_USER\AppData\Local\Programs\CURRENT_IMMORTAL_CLIENT\Immortal\Saved\Config\WindowsClient\`.
Remember to use proper values for `YOUR_USER` and `CURRENT_IMMORTAL_CLIENT`.

There will be a blank `Input.ini` file in this folder. You can safely override it with your modified file.

## Testing

Restart the IGP client, and try out your new hotkey setup!

## Trouble Shooting

If running into trouble, ask for help in the `hotkeys` channel in the IGP Discord.