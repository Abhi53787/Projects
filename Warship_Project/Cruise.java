package Warship_Project;

public class Cruise extends Warhead {

	public Cruise(String name, int range, String payload ) {
		super(name, range, payload);
				
	}

	@Override
	public void initialize() {
		System.out.println("Cruise Intilize");
		setStatus("intilize");
	
		
	}

	@Override
	public void arm() {
		System.out.println("Cruise armed");
		setStatus("armed");

		
	}

	@Override
	public void launch() { 
		System.out.println("Cruise launched");
		setStatus("launched");
	}
	
	

}
