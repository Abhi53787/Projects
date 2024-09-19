package Warship_Project;

public class Ballistic extends Warhead{

	public Ballistic(String name, int range, String payload ) {
		super(name, range, payload);
		
	}

	@Override
	public void initialize() {
		System.out.println("Intilized succesful");
		setStatus("Intilize");
	
		
	}

	@Override
	public void arm() {
		System.out.println("armed succesful");
		setStatus("armed");
	
		
	}

	@Override
	public void launch() {
		System.out.println("launched succesful");
		setStatus("launched");
	
		
		
	}
	

}
