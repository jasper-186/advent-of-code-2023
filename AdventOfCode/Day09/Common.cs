namespace AdventOfCode.Day09;

using System.Collections;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

public static class Sequence{
    public static long GetNextInSequence(List<long> list){
        if(list.Count<1){
            throw new IndexOutOfRangeException("Fuck Off");
        }

        if(list.All(i=>i==0)){
            return 0;
        }
        
        List<long> derivedList= new List<long>();
        for(var i=0;i<(list.Count-1);i++){
            //first
            var m=list[i];
            var n=list[i+1];
            derivedList.Add(n-m);
        }

        var nextDev=Sequence.GetNextInSequence(derivedList);
        return list.LastOrDefault()+nextDev;
    }

     public static long GetPreviousInSequence(List<long> list){
        if(list.Count<1){
            throw new IndexOutOfRangeException("Fuck Off");
        }

        if(list.All(i=>i==0)){
            return 0;
        }
        
        List<long> derivedList= new List<long>();
        for(var i=0;i<(list.Count-1);i++){
            //first
            var m=list[i];
            var n=list[i+1];
            derivedList.Add(n-m);
        }

        var previousDev=Sequence.GetPreviousInSequence(derivedList);
        return list.FirstOrDefault()-previousDev;
    }
}