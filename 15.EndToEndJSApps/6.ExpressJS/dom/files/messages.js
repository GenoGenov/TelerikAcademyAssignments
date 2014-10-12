var mongoose=require('mongoose');
var userSchema=mongoose.model('User').schema;
var messageSchema=new mongoose.Schema({
    from:{type:mongoose.Schema.ObjectId,ref:'User',required:true},
    to:{type:mongoose.Schema.ObjectId,ref:'User',required:true},
    text:{type:String,min:1,max:999999,required:true}
});
messageSchema.path('from').validate(function (from) {
//    if(!this.from.id || !this.to){
//        return true;
//    }
    return this.from.id!==this.to.id;
});



var Message=mongoose.model('Message',messageSchema);

module.exports=Message;