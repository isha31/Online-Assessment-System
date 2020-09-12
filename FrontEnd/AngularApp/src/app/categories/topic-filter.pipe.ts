import { Pipe, PipeTransform } from '@angular/core';
import { topic } from './category.service';

@Pipe({
  name: 'topicFilter'
})
export class TopicFilterPipe implements PipeTransform {

  transform(topics: topic[], searchkey : string): any {
    console.log("filter called, Searchkey = "+searchkey+"DAta = "+topics);
    
    if(!topics || !searchkey){
      return topics; 
    }
    return topics.filter(top => top.TopicName.toLowerCase().indexOf(searchkey.toLowerCase()) != -1);
  }

}
