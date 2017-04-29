//
//  ViewController.swift
//  no-uv
//
//  Created by Emad Kamal on 4/28/17.
//  Copyright © 2017 Emad Kamal. All rights reserved.
//

import UIKit
import CoreLocation

class ViewController: UIViewController, CLLocationManagerDelegate {
    
//    @IBOutlet weak var mapView: MKMapView!
    @IBOutlet weak var uvIndexLabel: UILabel!
//    @IBOutlet weak var uvIndexBar: UIProgressView!
    @IBOutlet weak var warningLevelLabel: UILabel!
    @IBOutlet weak var warningLevelBar: UIProgressView!
    @IBOutlet weak var warningMessageLabel: UILabel!
    @IBOutlet weak var activityIndeicatorView: UIActivityIndicatorView!
    @IBOutlet weak var button: UIButton!
    @IBOutlet weak var currentCityLabel: UILabel!
    @IBOutlet weak var cityImageView: UIImageView!
    @IBOutlet weak var currentLocationLabel: UILabel!
    
    
    var locationManager: CLLocationManager!
    var currentLocation: CLLocation!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        self.warningLevelBar.transform = self.warningLevelBar.transform.scaledBy(x: 1, y: 10)
        UIApplication.shared.statusBarStyle = .lightContent
        if (CLLocationManager.locationServicesEnabled())
        {
            locationManager = CLLocationManager()
            locationManager.delegate = self
            locationManager.desiredAccuracy = kCLLocationAccuracyBest
            locationManager.distanceFilter = kCLDistanceFilterNone
            locationManager.requestAlwaysAuthorization()
            locationManager.requestWhenInUseAuthorization()
            if CLLocationManager.authorizationStatus() == CLAuthorizationStatus.authorizedWhenInUse {
//                print("permission granted")
                locationManager.startUpdatingLocation()
            }
        }
        
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    @IBAction func checkCurrentLocationRadiations() {
        self.button.isHidden = true
        self.activityIndeicatorView.isHidden = false
        self.cityImageView.alpha = 0
        self.cityImageView.image = #imageLiteral(resourceName: "city")

        
        DispatchQueue.main.async() {
            // Do UI stuff here
//            self.uvIndexLabel.text = "7"
//            self.warningLevelLabel.text = "3"
//            self.warningLevelBar.setProgress(0.8, animated: true)
//            self.warningLevelBar.progressTintColor = UIColor.yellow
            UIView.animate(withDuration: 1.5, animations: {
                self.cityImageView.alpha = 1.0
                self.currentLocationLabel.alpha = 1.0
            })
//            self.button.isHidden = false
//            self.activityIndeicatorView.isHidden = true
        }
        
        let url = URL(string: "http://192.168.44.82/nasa/api/Values/")
        
        let task = URLSession.shared.dataTask(with: url!) { data, response, error in
            guard error == nil else {
                print(error!)
                return
            }
            guard let data = data else {
                print("Data is empty")
                return
            }
            
            let json = try! JSONSerialization.jsonObject(with: data, options: []) as! NSArray
//            print(json)
            DispatchQueue.main.async() {
                // Do UI stuff here
                let progress = Float(json[2] as! String)
                self.uvIndexLabel.text = json[0] as? String
                self.warningLevelLabel.text = json[1] as? String
                self.warningLevelBar.setProgress(progress!, animated: true)
                self.warningLevelBar.progressTintColor = self.getColorFromLevel(level: (json[1] as? String)!)
                
                self.button.isHidden = false
                self.activityIndeicatorView.isHidden = true
            }
        }
        
        task.resume()
    }
    
    func getColorFromLevel(level: String) -> UIColor {
        var color: UIColor!
        switch level {
        case "Low":
            color = UIColor.green
        case "Medium":
            color = UIColor.yellow
        case "High":
            color = UIColor.orange
        case "Very High":
            color = UIColor.red
        default:
            color = UIColor.purple
        }
        
        return color
    }
    
    func locationManager(manager: CLLocationManager!, didUpdateLocations locations: [AnyObject]!) {
//        let location = locations.last as! CLLocation
//        self.currentLocation = locations.last as! CLLocation
//        print("\(locations)")
        let locValue:CLLocationCoordinate2D = manager.location!.coordinate
        print("locations = \(locValue.latitude) \(locValue.longitude)")
        
//        let center = CLLocationCoordinate2D(latitude: location.coordinate.latitude, longitude: location.coordinate.longitude)
//        let region = MKCoordinateRegion(center: center, span: MKCoordinateSpan(latitudeDelta: 0.01, longitudeDelta: 0.01))
        
//        self.mapView.setRegion(region, animated: true)
    }
    
    func locationManager(_ manager: CLLocationManager, didFailWithError error: Error) {
        print("\(error)")
    }

}

