# FFXIV DPS Widget for WigiDash

A widget for the G.SKILL WigiDash that displays real-time combat statistics from Final Fantasy XIV using Advanced Combat Tracker (ACT).

## Features

- Real-time display of DPS (damage per second) metrics
- Table view of party members with job icons, DPS, and more stats
- Separate display for healers' HPS (healing per second) metrics
- Optimized for the WigiDash's small screen
- Color-coded job icons for easy identification
- Automatic reconnection to ACT

## Requirements

- G.SKILL WigiDash device
- WigiDash Manager installed
- Advanced Combat Tracker with FFXIV Plugin
- OverlayPlugin with WebSocket server enabled

## Setup Instructions

### 1. Build the Project

1. Open `FFXIVDPSWidget.sln` in Visual Studio
2. Make sure the WigiDashWidgetFramework.dll reference is correct:
   - Path should be: `C:\Program Files (x86)\G.SKILL\WigiDash Manager\WigiDashWidgetFramework.dll`
3. Build the solution (F6 or Build > Build Solution)

### 2. Configure ACT

1. Install OverlayPlugin for ACT if not already installed
2. Enable the WebSocket server in OverlayPlugin settings:
   - Under "Overlay WSServer", check "Enable WebSocket Server"
   - Default port is 10501

### 3. Add Widget to WigiDash

1. Open WigiDash Manager
2. Go to the Edit page (pencil icon)
3. Click the "+" icon to add a widget
4. Select "FFXIV DPS Dashboard" from the list
5. Choose the size you want
6. Save your changes

### 4. Configure Widget

1. Click the gear icon on the widget to access settings
2. Set the ACT Endpoint (default is `ws://127.0.0.1:10501/ws`)
3. Choose display options (DPS/HPS tables)
4. Set color preferences or use Global Theme
5. Save settings

## Usage

- The widget will automatically connect to ACT and display combat data during encounters
- Click the widget to toggle between DPS and HPS views
- If no data is shown, make sure ACT is running with OverlayPlugin and check your connection settings

## Troubleshooting

- If no data appears, check that ACT is running with OverlayPlugin
- Verify the WebSocket server is enabled in OverlayPlugin
- Ensure the ACT Endpoint in widget settings matches your OverlayPlugin configuration
- For local testing, the widget will display mock data if it can't connect to ACT

## Development

This widget is built using the WigiDash Widget Framework. The main components are:

- `WidgetServer.cs` - Main widget class implementing IWidgetObject
- `WidgetInstance.cs` - Widget instance class with drawing logic
- `ACTDataConnector.cs` - WebSocket client for ACT communication
- `SettingsControl.xaml` - UI for configuring the widget

Feel free to fork and customize the widget for your needs.

## Credits

- Widget developed by: Your Name
- Built for the G.SKILL WigiDash
- Uses ACT and OverlayPlugin for FFXIV data