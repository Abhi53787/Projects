package Warship_Project;

abstract class Warhead {
	private String name;
	private int range;
	private String payload;
	private String status;
	
	public Warhead(String name , int range , String payload  ) {
		this.setName(name);
		this.setRange(range);
		this.setPayload(payload);
		this.status=null;
				
		
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getRange() {
		return range;
	}

	public void setRange(int range) {
		this.range = range;
	}

	public String getPayload() {
		return payload;
	}

	public void setPayload(String payload) {
		this.payload = payload;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}
	
	 public abstract void initialize();
	    public abstract void arm();
	    public abstract void launch();
	

}
