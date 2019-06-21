
import React from 'react';
import { Platform, Text, View, StyleSheet, ScrollView } from 'react-native';
import { Card, Button } from 'react-native-elements';
import { createStackNavigator, createAppContainer } from 'react-navigation';
import {Icon} from 'react-native-elements';



// const MainNavigator = createStackNavigator({
//   Home: { screen: App },
//   Details: { screen: DetailScreen },
// });

// const nav = createAppContainer(MainNavigator);

// export default nav; // all the above lines added



 export default class App extends React.Component {
  static navigationOptions = {
    title: 'welcome',
  };
  //all above added

  render() {
    // const { navigate } = this.props.navigation;// added
    return (
      <ScrollView>
        <View style={styles.container}>

          <Card title="Local Modules">
            {/*react-native-elements Card*/}
            <Text style={styles.paragraph}>
              This is a card from the react-native-elements
          </Text>
      
          {/* <button
          icon={<Icon name='Arrow_right' color = '#000000'></Icon>}
          backgroundColor = '#f0f8ff'
          buttonStyle={{borderRadius: 0, marginLeft: 0, marginRight: 0, marginBottom: 0}}
          title = 'Veiw'
          /> */}
              {/* every card has its button veiw icon  */}
          </Card>

          <Card title="Modules">
            {/*react-native-elements Card*/}
            <Text style={styles.paragraph}>
              This is a card from the react-native-elements
          </Text>
          {/* <button
          icon={<Icon name='arrow_right' color = '#000000'></Icon>}
          backgroundColor = '#f0f8ff'
          buttonStyle={{borderRadius: 0, marginLeft: 0, marginRight: 0, marginBottom: 0}}
          title = 'Veiw'
          /> */}
          </Card>

          <Card title="Local Modules">
            {/*react-native-elements Card*/}
            <Text style={styles.paragraph}>
              This is a card from the react-native-elements
          </Text>
          {/* <button
          icon={<Icon name='arrow_right' color = '#000000'></Icon>}
          backgroundColor = '#f0f8ff'
          buttonStyle={{borderRadius: 0, marginLeft: 0, marginRight: 0, marginBottom: 0}}
          title = 'Veiw'
          /> */}
          </Card>

          <Card title="Local Modules">
            {/*react-native-elements Card*/}
            <Text style={styles.paragraph}>
              This is a card from the react-native-elements
          </Text>
          {/* <button
          icon={<Icon name='arrow_right' color = '#000000'></Icon>}
          backgroundColor = '#f0f8ff'
          buttonStyle={{borderRadius: 0, marginLeft: 0, marginRight: 0, marginBottom: 0}}
          title = 'Veiw'
          /> */}
          </Card>
{/* 
          <Button
            Title="home page"
            onPress={() => navigate('Details', { name: 'home' })}
          /> */}

        </View>
      </ScrollView>
    );
  }
}




const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    paddingTop: 40,
    backgroundColor: '#ecf0f1',
  },
  paragraph: {
    margin: 24,
    fontSize: 18,
    fontWeight: 'bold',
    textAlign: 'center',
    color: '#34495e',
  },


});