// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { makeAutoObservable } from 'mobx';

export default class ActivityStore {
  title = 'Hello from Mobx!';

  constructor() {
    makeAutoObservable(this);
  }

  //make sure is an arrow function so we don't need to bind the action in the ctor
  setTitle = () => {
    this.title = this.title + '!';
  };
}
