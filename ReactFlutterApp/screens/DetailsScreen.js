import React from 'react';
// import { createStackNavigator, createAppContainer } from 'react-navigation';
import {  Button } from 'react-native-element';


class DetailScreen extends React.Component{
    static navigationOptions ={
      title: "Details",
    };
    render(){
      const {navigate} = this.props.naviagation;
      return(
        <Button 
        title= ""
        onPress={() => navigate('Profile', {name: 'Jane'})}
        />
      )
    }
  
  }