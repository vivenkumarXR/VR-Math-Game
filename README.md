# VR-Math-Game
VR Math Practice Game An immersive Unity-based VR experience that makes learning math fun! Solve addition problems by placing cubes over numbered spheres to match a displayed result. Use intuitive hand gestures like Shaka and thumbs-up to interact. Features include a practice mode, countdown challenge, and gamified learning in VR!


# VR Math Practice Game

A Unity-based VR experience designed to make learning math fun and interactive! In this game, users solve addition problems by placing cubes over spheres marked with numbers. The goal is to ensure the sum of the selected cubes matches the displayed result, all within a time limit. The experience is enhanced with hand gesture controls for starting and restarting the game.

---

## Features
- **Interactive Gameplay:** Place cubes over numbered spheres to achieve the displayed sum.
- **Gesture Controls:** 
  - Perform a Shaka gesture with your right hand to start the game.
  - Perform a thumbs-up gesture with your left hand to restart.
- **Timer Challenge:** Solve the problem within 10 seconds to win.
- **Practice Mode:** A guided demo helps players understand the gameplay mechanics.

---

## Setup Instructions

### Prerequisites
- Unity (version 2021.3 or later recommended)
- XR Plugin Management for VR headset support
- TextMeshPro (already integrated in Unity)
- A VR headset with hand tracking capabilities (e.g., Oculus Quest or similar)

Importing the Project
Open Unity Hub.
Click Add and select the cloned project folder.
Open the project in Unity.



Configuring XR
Navigate to Edit > Project Settings > XR Plug-in Management.
Enable the XR plug-in for your target platform (e.g., Oculus, OpenXR).
Ensure your VR headset is connected and properly set up.



How to Play
Launch the game in your VR headset.
Follow the on-screen instructions:
To Start: Perform a Shaka gesture with your right hand.
Objective: Place cubes over the correct spheres to match the displayed result.
To Restart: Perform a left-hand thumbs-up gesture.
A timer will count down from 10 seconds. Solve the problem before time runs out!



Key Functions and Logic
Game Flow
Game Start: The game begins with the RaiseRightHandThumpsUp function in the FlowManager script.
Result Generation: A random result is generated using the GenerateResult method.
Cube Placement Validation: Players’ placements are validated via collision detection and logic in the CalculateValue function.



Gesture Detection
Hand gestures are tracked using the XR Hands SDK. Key gestures include:
Shaka Gesture: Starts the game.
Thumbs-Up Gesture: Restarts the game.
Timer
A countdown timer is implemented using coroutines in the FlowManager script. The timer dynamically updates in the UI.


Challenges and Creative Solutions
Gesture Recognition
Implementing reliable gesture recognition for specific hand gestures like Shaka required careful calibration of the hand-tracking SDK.

Real-Time Feedback
Integrating TextMeshPro for dynamic text updates helped improve the clarity of instructions and real-time feedback during gameplay.

Enhanced Immersion
Using a guided practice mode with animated hand models and visual cues allows new players to quickly grasp the game mechanics.




Future Enhancements
Add levels with increasing difficulty.
Implement multiplayer functionality for collaborative learning.
Enhance UI with additional visual feedback for gestures and correct/incorrect answers.

Credits
Developed by Vivek Kumar Yadav
For queries or feedback, contact: vivek.kumar2154@gmail.com
