package Warship_Project;
import java.util.*;
public class Navymain {
	public static void main(String [] args) {
		Scanner sc = new Scanner(System.in);
	 
		Submarine sub = new Submarine("Indian Navy ");
		
		while(true) {
			System.out.println(" Indian navy Nuclear missile Radar System");
			System.out.println("1. add missile");
			System.out.println("2. deploy missile");
			System.out.println("3. status missile");
			System.out.println("4. Exit");
            System.out.print("Choose an option: ");
            int choice = sc.nextInt();
            switch(choice) {
            case 1 :
            	System.out.println("Just give a name for the missile ");
            	String name = sc.next();
            	System.out.println("Just give range for the missile ");
            	int range = sc.nextInt();
            	System.out.println("Just give the payload of the missile  wheather nuclear or normal ");
            	String payload = sc.next();
            	System.out.println("select missile type 1.Ballistic 2.Cruise 3.Torpedo");
            	int type = sc.nextInt();
            	Warhead war = null;
            	switch(type) {
            	
            	case 1 :
            		war = new Ballistic (name ,range,payload);
            		break;
            	case 2 :
            		war = new Cruise(name,range,payload);
            		break;
            	case 3 :
            		war = new Torpedo(name,range,payload);
            		break;
            	default:
                	System.out.println("Invalid type.");
                    continue;
            	           	
            	}
            	 sub.addWarhead(war);
            	 break;
            case 2:
                System.out.print("Just Enter the name of the Missile to deploy: ");
                String deployName = sc.next();
                sub .deployWarhead(deployName);
                break;

            case 3:
                sub .statuswarhead( );
                break;

            case 4:
                System.out.println("Exiting...");
                 
                return;

            default:
                System.out.println("Invalid choice. Please try again.");
            	
            	
            }
            
           
            
	            
		}
	}
	

}
