# Changelog
All notable changes to this project will be documented in
this file.

## v1.2.0 - 2022/04/28
### Added
* added checkboxes to show/hide Hours, Minutes, Seconds if 0
* added a "Restart" button
* added a "Close Timer" button which also resets the timer when
timer is started again
* added font choices and background colors for each of the 3
states: `running`, `paused`, and `ended` with a preview for each
* added a duplicate of the elapsed time on the app for when the
timer is used on a display which is inaccessible to the user - 
e.g. if the timer window is used on a remote projector which the
user is unable to see
* added capability to play a sound file (\*.wav only) after
timer ends
* added a button which appears when an update is available
* added links to my profiles
### Changed
* changed the "Start" button to act as a "Start" and "Pause"
button
* moving the timer window now updates the window location
values on the app
* main window no longer disappears upon starting the timer
* changed .NET dependency from 2.0 to 4.6 so it would run
without any additional downloads on Windows 10
* some elements of the UI
### Removed
* removed mouse shortcuts
### Known Issues
* erroneous values related to DPI scaling: resolution of the
listed displays when the "Fullscreen" option is enabled and
the Location and Size of the timer window (related to DPI
scaling)

## v1.1.2 - 2020/02/07
* option to select fullscreen display is now working
as expected
* fixed error when running the program for the first time
without proper size and location values

## v1.1.1 - 2018/07/xx
* added option to select which display to use when
fullscreen is checked
* added location options of the timer display when
fullscreen is checked

## v1.1.0 -2017/05/09 21:08
* downgraded .NET requirement from 4.0 to 2.0 (Windows 7
and later should have no problems running this app now)
* added shortcuts on timer window: double-click to reset timer,
left-click to pause/continue timer
* fixed some initialization bugs (i.e. missing initial settings
caused the program to crash)
* added icons for main window and timer window

## v1.0.0a - 2017/05/03 18:33
* added icon

## v1.0.0 - 2017/04/26 19:57 GMT+08:00
* initial release