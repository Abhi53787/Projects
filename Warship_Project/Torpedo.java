package Warship_Project;

public class Torpedo extends Warhead {

	public Torpedo(String name, int range, String payload ) {
		super(name, range, payload );
	}
		

	@Override
	public void initialize() {
		System.out.println("Torpedo intilize");
		setStatus("intilize");
 
		
	}

	@Override
	public void arm() {
		System.out.println("Torpedo armed");
		setStatus("armed");
 
	 
	}

	@Override
	public void launch() { 
		System.out.println("Torpedo launched");
		setStatus("launched");
 
		
	}

}

