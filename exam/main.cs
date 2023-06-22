using System;

public class Particle
{
    public double[] Position { get; set; }
    public double[] Velocity { get; set; }
    public double[] BestPosition { get; set; }
    public double BestFitness { get; set; }
}

public class PSO
{
    private int swarmSize;
    private int dimensions;
    private double inertiaWeight;
    private double cognitiveWeight;
    private double socialWeight;
    private double[] globalBestPosition;
    private double globalBestFitness;
    private Particle[] particles;
    private Random random;

    public PSO(int swarmSize, int dimensions, double inertiaWeight, double cognitiveWeight, double socialWeight)
    {
        this.swarmSize = swarmSize;
        this.dimensions = dimensions;
        this.inertiaWeight = inertiaWeight;
        this.cognitiveWeight = cognitiveWeight;
        this.socialWeight = socialWeight;

        particles = new Particle[swarmSize];
        random = new Random();

        globalBestPosition = new double[dimensions];
        globalBestFitness = double.MaxValue;

        for (int i = 0; i < swarmSize; i++)
        {
            particles[i] = new Particle();
            particles[i].Position = new double[dimensions];
            particles[i].Velocity = new double[dimensions];
            particles[i].BestPosition = new double[dimensions];
            particles[i].BestFitness = double.MaxValue;

            for (int j = 0; j < dimensions; j++)
            {
                particles[i].Position[j] = random.NextDouble() * 100;  // Randomly initialize particle position
                particles[i].Velocity[j] = random.NextDouble();       // Randomly initialize particle velocity
                particles[i].BestPosition[j] = particles[i].Position[j];
            }

            double fitness = CalculateFitness(particles[i].Position);
            particles[i].BestFitness = fitness;

            if (fitness < globalBestFitness)
            {
                globalBestFitness = fitness;
                particles[i].Position.CopyTo(globalBestPosition, 0);
            }
        }
    }

    public void Run(int maxIterations)
    {
        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            for (int i = 0; i < swarmSize; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    // Update velocity
                    particles[i].Velocity[j] = inertiaWeight * particles[i].Velocity[j]
                        + cognitiveWeight * random.NextDouble() * (particles[i].BestPosition[j] - particles[i].Position[j])
                        + socialWeight * random.NextDouble() * (globalBestPosition[j] - particles[i].Position[j]);

                    // Update position
                    particles[i].Position[j] += particles[i].Velocity[j];

                    // Check boundaries
                    if (particles[i].Position[j] < 0)
                        particles[i].Position[j] = 0;
                    else if (particles[i].Position[j] > 100)
                        particles[i].Position[j] = 100;
                }

                double fitness = CalculateFitness(particles[i].Position);

                // Update personal best
                if (fitness < particles[i].BestFitness)
                {
                    particles[i].BestFitness = fitness;
                    particles[i].Position.CopyTo(particles[i].BestPosition, 0);
                }

                // Update global best
                if (fitness < globalBestFitness)
                {
                    globalBestFitness = fitness;
                    particles[i].Position.CopyTo(globalBestPosition, 0);
                }
            }

            Console.WriteLine($"Iteration {iteration + 1}: Best Fitness = {globalBestFitness}");
        }

        Console.WriteLine("Optimization finished!");
    }

    private double CalculateFitness(double[] position)
    {
        // TODO: Implement your fitness function here
        // This method should return the fitness value for the given position

        // Placeholder code that calculates the sum of the position values
        double sum = 0;
        foreach (var p in position)
        {
            sum += p;
        }
        return sum;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int swarmSize = 30;
        int dimensions = 10;
        double inertiaWeight = 0.729;
        double cognitiveWeight = 1.49445;
        double socialWeight = 1.49445;

        PSO pso = new PSO(swarmSize, dimensions, inertiaWeight, cognitiveWeight, socialWeight);
        pso.Run(100);
    }
}
