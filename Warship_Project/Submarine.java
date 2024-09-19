package Warship_Project;

import java.util.ArrayList;
import java.util.List;

public class Submarine {
	private List<Warhead> warheads = new ArrayList<>();
	private String submarineName;
	public Submarine(String submarineName ) {
		this.submarineName =submarineName;
		this.warheads=new ArrayList<>();	
	}
	public   void addWarhead(Warhead warhead) {
		warheads.add(warhead);

        System.out.println(warhead.getName() + " added to the submarine.");
	}
	public void deployWarhead(String warheadName) {
		for(Warhead war : warheads) {
			if(war.getName().equalsIgnoreCase(warheadName)) {
				war.initialize();
				war.arm();
				war.launch();
				return;
			}
			
		}System.out.println( "No missile found ");
		
	}
	public void statuswarhead( ) {
		System.out.println("Missile status of ");
		for(Warhead war : warheads) {
			System.out.println(war.getName()+""+war.getStatus());
		}
		
	}
	
	
	
 

}
