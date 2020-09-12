import { AppPage } from './app.po';
import { browser, by, element } from 'protractor';

describe('workspace-project App', () => {
  let page: AppPage;

  beforeEach(() => {
    browser.get('/');
  });

  it('should display the name of the application',() => {
    
    expect(browser.getTitle()).toEqual('OAS');
    
  });
   

  

 
});
