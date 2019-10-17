Networking -SignalR
	Matchmaking Hub
	Clients
		Interfaces	
			IAction
				IMouseClick
				IKeyPress
				ISelectionBox
GameEngine -C#/Lua - LockStep
	Interfaces
		IGameObject
			IStructure
				IUnitFactory
					IAirFactory
					ILandFactory
					INavelFactory
				IResourceCollector
					IEnergy
					IMass
					ISupply
				IGarison
				IStaticDefence
				
			IUnit
				IAirUnit
				INavelUnit
				ILandUnit
		ISpawnPoint
		IMap
		IPlayer
		IPlayerController
Rendering -C#/Mogre