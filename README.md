# 🧪 Potion Academy

A cozy, hand-crafted **potion-sorting puzzle game** built in Unity. Inspired by the "water/ball sort" genre, but wrapped in its own calm alchemy-academy setting: you start as an apprentice and rise through academic ranks by sorting colored potion layers into the right bottles.

> **Status:** Early development / learning-focused prototype. The core interaction loop (select a bottle, pour a matching layer into another) is playable. Level data, win conditions, and progression are on the roadmap below.

---

## 🎯 Concept

Each bottle holds a stack of colored liquid layers. A move pours the **top** layer of one bottle onto another, but only when the pour is valid:

- The source bottle is not empty.
- The target bottle is not full.
- The target is empty **or** its top color matches the color being poured.

The goal of a finished level is to gather each color into its own bottle. The design keeps a relaxed, low-pressure feel: no timers, no punishment, just satisfying sorting.

## ✅ Currently Implemented

- **Bottle model:** configurable capacity and an ordered stack of color layers (`List<Color>`), rendered as stacked visual segments that resize to the bottle.
- **Click-based selection:** click a bottle to select it (visual highlight), click again to deselect.
- **Single-layer transfer with valid-move rules:** selecting a source then clicking a target pours one layer if the move is legal.
- **2D setup on Universal Render Pipeline** with Unity's new Input System for mouse input.

## 🗺️ Roadmap

- [ ] Multi-layer pour (move a whole run of same-colored layers in one action)
- [ ] Level data driven by **ScriptableObjects** (colors, bottle count, starting layout)
- [ ] Win-condition detection and level-complete flow
- [ ] Level select and progression (apprentice to master ranks)
- [ ] Save / load of player progress
- [ ] Audio and juice (pour tween, SFX, feedback)
- [ ] Undo / reset move

## 🛠️ Tech Stack

- **Engine:** Unity `6000.5.2f1` (Unity 6)
- **Rendering:** Universal Render Pipeline (2D Renderer)
- **Input:** Unity Input System package
- **Language:** C#

## 🏗️ Architecture

The project favors small, single-responsibility scripts over large monolithic controllers:

| Script | Responsibility |
| --- | --- |
| `Bottle` | Owns a bottle's layer data (capacity, colors), renders the visual segments, and exposes queries (`IsEmpty`, `IsFull`, `TopColor`) plus mutations (`AddLayer`, `RemoveTopLayer`). |
| `SelectionManager` | Handles input: converts clicks to bottles, tracks the selected source, and runs the transfer rules to decide whether a pour is legal. |

Gameplay data lives on the components; interaction logic lives in the manager. As the game grows, level configuration is planned to move into ScriptableObjects so levels are data-driven rather than hard-coded.

## 📁 Project Structure

```text
Assets/_Project/
  Art/          Sprites, UI, effects
  Audio/        Music and SFX
  Data/         Level / potion / rank data (planned ScriptableObjects)
  Prefabs/      Bottle and layer-segment prefabs
  Scenes/       MainScene
  Scripts/
    Core/       SelectionManager
    Gameplay/   Bottle
    ...         Data, Level, Save, UI, Audio, Utilities (as the game grows)
```

## 🚀 Getting Started

1. Install **Unity 6** (`6000.5.2f1` or a compatible 6000.5.x release), e.g. via Unity Hub.
2. Clone this repository and open the folder as a project in Unity Hub.
3. Open `Assets/_Project/Scenes/MainScene.unity`.
4. Enter Play Mode, click a bottle to select it, then click another to pour.

## 📖 About This Project

Potion Academy is a portfolio project focused on learning Unity the right way: clean game-loop design, data-driven level structure, modular managers, and readable code. It is being built incrementally, feature by feature, with each step kept small and reviewable.
