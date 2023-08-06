# AudioControlApp

## Description

La **AudioControlApp** is an application developed in C# with the use of the .NET framework that allows you to have full control over the audio of your applications. With this tool, you will be able to manage the volume and audio playback through customizable key combinations, even from other running programs and games.

## 🏭 Releases
Check [here](https://github.com/illoIvan/AudioAppController/releases) latest releases to download

## Characteristics

- **Audio Control with Key Combinations:** Customize key combinations to adjust volume, mute or stop application audio playback in real time.

- **Compatibility:** The application is capable of interacting with any running program or game, allowing you to manage audio effectively regardless of the source.

- **Process management:** The application maintains a list of running processes. You can easily reload the list with the "Reload" buttons, and you can also add processes to the view by clicking on them.

- **Mute All y Add All:** Quickly mute all listed applications with the "Mute All" button or add all processes to the list with the "Add All" button.

- **Customization by Process:** Each process in the list can be configured with a key combination and there can be several with the same combination, allowing you to mute its volume from anywhere using this combination. Also, you can activate the mute mode by clicking on "Mute" or kill the process with the "X" button.

- **Media Control:** The app also offers media control features, such as "Next Track" to go to the next song, "Previous Track" to go back to the previous song, "Media Play/Pause" to stop or resume playback, "Media Stop" to completely stop playback and "Mute Volume" to mute the Windows volume.

## Application interface

![Image of the application interface](https://github.com/illoIvan/AudioAppController/assets/40025251/d39a6624-55d2-4be3-8417-e38ac385a4d6)

## Dependencies:

- [Simon Mourier](https://stackoverflow.com/users/403671/simon-mourier)
  - The code to take the audio processes and be able to control their volume was taken from stackoverflow. The author is Simon Mourier.
  Code link: https://stackoverflow.com/questions/20938934/controlling-applications-volume-by-process-id

- [H.InputSimulator](https://www.nuget.org/packages/H.InputSimulator/) (v1.4.0)
  - Library for the simulation of keyboard and mouse inputs.

- [MouseKeyHook](https://www.nuget.org/packages/MouseKeyHook/) (v5.7.1)
  - Library for the capture and manipulation of keyboard and mouse events.

- [NET framework]() (v4.7.2)

## License [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

The code in this repository is covered by the included license.

## Contributing
You can contribute to this project and improve with new ideas. If you find any issues, please post them in the issues section of the repository. Thank you.
