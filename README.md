# Presentation

Tempo Sword is the result of a quick Beat Saber like VR project. I wished to experiment with VR a bit further and since Beat Saber is one of my favorite game on that platform, I wanted to try and see if I could implement a few mechanics from the game myself.

# Development

This game was made with [Unity](https://unity.com/fr) and the assets were found on the [ Asset Store of Unity](https://assetstore.unity.com/).
The music used in this project is [Newer Wave by Kevin MacLeod](https://www.youtube.com/watch?v=T-4jRyT8lDc&ab_channel=KevinMacLeod). It is an easy song to work with as the beats are easy to notice. I used the [XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.5/manual/index.html) to set up the VR system.

# Demo

![Gif_TempoSword](https://github.com/marionpobelle/Tempo-Sword/assets/112869026/3ebc9078-e9a1-4a50-92b9-0cda5c8035cf)

https://github.com/marionpobelle/Tempo-Sword/assets/112869026/345a8f58-9220-406b-8c04-33a1a126a608

# TDL

- [x] GAMEPLAY
- - [x] Environment (platform, track lines, track beat lines)
- - [x] Blocks (model, behavior, SFX, hit)
- - [x] Miss Hit Detector
- - [x] Track (beats)
  
- [x] SYSTEM
- - [x] Game Manager (score, life, end game logic, velocity threshold)
- - [x] Automated block map generation on track
- - [x] Velocity Tracker (on controllers)
- - [x] Audio Manager (SFX, music)
- - [x] Song Data (characteristics)
  
- [x] UI
- - [x] Position and Size
- - [x] Display score
- - [x] Display life

- [x] VR
- - [x] Set up XR Origin
- - [x] Set up controllers
- - [x] Models for controllers
