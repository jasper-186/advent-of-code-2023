namespace AdventOfCode.Day06;
public class Race{
  public long time{get;private set;}
  public long distance{get;private set;}
  public Race(long time, long distance){
    this.time=time;
    this.distance=distance;
  }

  public int solve(){
    //Brute force
    // for every sec you hold the button, 
    // speed increases by 1
    var running_total=0;
    for(int i=1;i<=time;i++){
      // i is time held the button
      var dist = (time-i)*i;
      if(dist>this.distance){
        running_total+=1;
      }
    }
    
    return running_total;
  }
}